import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  inventoryForm: FormGroup;
  inventoryId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private inventoryService: InventoryService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.inventoryForm = this.fb.group({
      name: ['', Validators.required],
      code: ['', Validators.required],
      quantity: [0, [Validators.required, Validators.min(1)]],
      description: [''],
      thumbnail: [''],
      id: [0]
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

    const inventoryData: Inventory = this.inventoryForm.value;
    inventoryData.quantity = inventoryData.quantity.toString();
    if (this.inventoryId) {
      this.inventoryService.update(inventoryData).subscribe({
        next: () => {
          this.router.navigate(['/inventory/list']);
        },
        error: (error) => {
          console.error('Error updating inventory', error);
        }
      });
    }
  }


}
