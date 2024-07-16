import { Component, OnInit } from '@angular/core';
import { Inventory } from '../inventory.model';
import { InventoryService } from '../inventory.service';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

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
  imageUrl : string | null  = '';

  constructor(private _service: InventoryService, private _router: Router) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    this._service.list().subscribe({
      next: (data) => {
        this.data = data;
        this.data.forEach((item)=> {
          item.image = environment.MediaUploadUrl + item.image;
        })
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

  delete(id: number, index: number): void {
    let res = confirm("Do you really want to delete this member?");
    if(res){
      this._service.delete(id).subscribe(() => {
        this.data = this.data.filter(member => member.id !== id);
      });
      this.deleteLine(index);
    }
  }

  deleteLine(index : number)
  {
    if(index !== -1)
    {
      this.data.splice(index, 1);
    }
  }

}
