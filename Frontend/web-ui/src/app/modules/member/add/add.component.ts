import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MemberService } from '../member.service';
import { Member } from '../member.model';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  pageParentLink = 'Member';
  pageTitle = 'Add Member';
  memberForm: UntypedFormGroup;
  selectedFile: File | null = null;
  imageUrl : string | null | ArrayBuffer = '';
  isLoading: boolean = false;

  constructor(
    private fb: UntypedFormBuilder,
    private memberService: MemberService,
    private _router: Router,
    private toastr: ToastrService
  ) {
    this.memberForm = this.fb.group({
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: [''],
      secondaryPhoneNumber: [''],
      birthDate: ['', Validators.required],
      gender: ['', Validators.required],
      occupation: ['', Validators.required],
      permanentAddress: ['', Validators.required],
      temporaryAddress: ['', Validators.required],
      baptizedDate: [''],
      membershipDate: [''],
      photoFile: [null]
    });
  }

  ngOnInit(): void {}

  onFileChange(event: any): void {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.selectedFile = file;
      this.memberForm.patchValue({
        photoFile: file
      });
      var reader = new FileReader();
      reader.readAsDataURL(event.target.files[0]); // read file as data url
      reader.onload = (event) => { // called once readAsDataURL is completed
        if(event.target)
        this.imageUrl = event.target.result;
      }
    }
  }

  onSubmit(): void {
    if (this.memberForm.valid) {
      this.isLoading = true;
      const member: Member = this.memberForm.value;
      const formData: FormData = new FormData();
      formData.append('firstName', member.firstName);
      formData.append('middleName', member.middleName || '');
      formData.append('lastName', member.lastName);
      formData.append('email', member.email);
      formData.append('phoneNumber', member.phoneNumber || '');
      formData.append('secondaryPhoneNumber', member.secondaryPhoneNumber || '');
      formData.append('birthDate', member.birthDate);
      formData.append('gender', member.gender);
      formData.append('occupation', member.occupation);
      formData.append('permanentAddress', member.permanentAddress);
      formData.append('temporaryAddress', member.temporaryAddress);
      formData.append('baptizedDate', member.baptizedDate);
      formData.append('membershipDate', member.membershipDate || '');
      if (this.selectedFile) {
        formData.append('photoFile', this.selectedFile);
      }

      this.memberService.create(formData).subscribe({
        next: (data) => {
          this.toastr.success('Member Created Successfully');
          this._router.navigate(['/member']);
        },
        error: (err) => {
          this.toastr.error('Something went wrong');
          console.error('Error creating member', err);
          this.isLoading = false;
        }
      });
    } else {
      this.memberForm.markAllAsTouched();
      this.isLoading = false;
    }
  }
}
