import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Inventory } from '../inventory.model';
import { InventoryService } from '../inventory.service';
import { stringify } from 'querystring';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  pageParentLink = 'Inventory';
  pageTitle = 'Add Item';
  inventoryForm!: UntypedFormGroup;

  constructor(private fb: UntypedFormBuilder, private inventoryService: InventoryService, private _router: Router) {}

  ngOnInit(): void {
    this.inventoryForm = this.fb.group({
      name: ['', Validators.required],
      code: ['', Validators.required],
      quantity: ['', [Validators.required, Validators.min(1)]],
      description: [''],
      thumbnail: ['']
    });
  }

  onSubmit(): void {
    if (this.inventoryForm.valid) {
      const inventory: Inventory = this.inventoryForm.value;
      inventory.quantity = (inventory.quantity).toString();
      this.inventoryService.create(inventory).subscribe({
        next: (response) => {
          console.log('Category created successfully', response);
          this._router.navigate([`/inventory`]);
        },
        error: (error) => {
          console.error('There was an error creating the category', error);
        }
      });
    } else {
      this.inventoryForm.markAllAsTouched();
    }
  }
}
