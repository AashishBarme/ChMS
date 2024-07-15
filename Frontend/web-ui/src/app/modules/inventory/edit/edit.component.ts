import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Inventory } from '../inventory.model';
import { InventoryService } from '../inventory.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  pageParentLink = 'Inventory';
  pageTitle = 'Edit Item';
  inventoryForm: UntypedFormGroup;
  inventoryId: number | null = null;
  selectedFile: File | null = null;
  constructor(
    private fb: UntypedFormBuilder,
    private inventoryService: InventoryService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.inventoryForm = this.fb.group({
      name: ['', Validators.required],
      code: ['', Validators.required],
      quantity: [0, [Validators.required, Validators.min(1)]],
      description: [''],
      id: [0],
      image: [''],
      imageFile: [null]
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.inventoryId = +params['id'];
        this.loadInventory();
      }
    });
  }

  onFileChange(event: any): void {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.selectedFile = file;
      this.inventoryForm.patchValue({
        imageFile: file
      });
    }
  }

  loadInventory(): void {
    if (this.inventoryId) {
      this.inventoryService.get(this.inventoryId).subscribe({
        next: (inventory) => {
          this.inventoryForm.patchValue(inventory);
        },
        error: (error) => {
          console.error('Error loading inventory data', error);
        }
      });
    }
  }

  onSubmit(): void {
    if (this.inventoryForm.invalid) {
      return;
    }
    const inventory: Inventory = this.inventoryForm.value;
    inventory.quantity = (inventory.quantity).toString();
      const formData: FormData = new FormData();
      formData.append('name', inventory.name);
      formData.append('code', inventory.code);
      formData.append('description', inventory.description || '');
      formData.append('image', inventory.image || '');
      formData.append('quantity', inventory.quantity);
      formData.append('id', inventory.id.toString());
      if (this.selectedFile) {
        formData.append('imageFile', this.selectedFile);
      }

    if (this.inventoryId) {
      this.inventoryService.update(formData).subscribe({
        next: () => {
          this.router.navigate(['/inventory']);
        },
        error: (error) => {
          console.error('Error updating inventory', error);
        }
      });
    }
  }


}
