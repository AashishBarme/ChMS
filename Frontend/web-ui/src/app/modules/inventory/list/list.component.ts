import { Component, OnInit } from '@angular/core';
import { Inventory } from '../inventory.model';
import { InventoryService } from '../inventory.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  pageParentLink = 'Inventory';
  pageTitle = 'List Item';
  data: Inventory[] = [];
  sortDirection = true;

  constructor(private inventoryService: InventoryService, private _router: Router) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this.inventoryService.list().subscribe({
      next: (data) => {
        this.data = data;
      },
      error: (error) => {
        console.error('Error loading inventory data', error);
      }
    });
  }

  sortTable(column: string): void {
    this.sortDirection = !this.sortDirection;
    this.data.sort((a:any, b:any) => {
      if (a[column] < b[column]) return this.sortDirection ? -1 : 1;
      if (a[column] > b[column]) return this.sortDirection ? 1 : -1;
      return 0;
    });
  }

  editItem(id: number): void {
    // Implement the edit functionality
    this._router.navigate([`/inventory/edit/${id}`]);
  }

  deleteItem(id: number): void {
    if (confirm('Are you sure you want to delete this item?')) {
      this.inventoryService.delete(id).subscribe({
        next: () => {
          this.data = this.data.filter(i => i.id !== id);
        },
        error: (error) => {
          console.error('Error deleting item', error);
        }
      });
    }
  }

}
