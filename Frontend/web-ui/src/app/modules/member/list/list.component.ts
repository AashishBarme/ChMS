import { Component, OnInit } from '@angular/core';
import { MemberService } from '../member.service';
import { ListMember } from '../member.model';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  constructor(private _service: MemberService, private toastr: ToastrService) { }
  pageParentLink = 'Member';
  pageTitle = 'List Member';
  items: any[] = [];
  errorMessage: string = '';
  imageUrl : string | null  = '';
  isLoading: Boolean = false;
  members: ListMember[] = [];

  ngOnInit(): void {
    this.isLoading = true;
    this._service.list().subscribe({
      next: (data) => {
        this.members = data;
        this.members.forEach((item)=> {
          item.photo = environment.MediaUploadUrl + item.photo;
        })
        this.isLoading = false
      },
      error: (error) => {
        this.toastr.error('Something went wrong');
        console.error('Error loading inventory data', error);
        this.isLoading = false
      }
    });
  }

  deleteMember(id: number, index: number): void {
    let res = confirm("Do you really want to delete this member?");
    if(res){
      this._service.delete(id).subscribe(() => {
        this.members = this.members.filter(member => member.id !== id);
      });
      this.deleteLine(index);
    }
  }

  deleteLine(index : number)
  {
    if(index !== -1)
    {
      this.members.splice(index, 1);
    }
  }


}
