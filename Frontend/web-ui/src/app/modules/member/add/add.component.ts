import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MemberService } from '../member.service';
import { Member } from '../member.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  pageParentLink = 'Member';
  pageTitle = 'Add Member';
  memberForm: FormGroup;
  ngOnInit(): void {
  }

  constructor(
    private fb: FormBuilder,
    private memberService: MemberService,
    private _router: Router ) {
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
      baptizedDate: ['', Validators.required],
      membershipDate: [''],
      photoUrl: ['']
    });
  }

  onSubmit() {
    if (this.memberForm.valid) {
      const member: Member = this.memberForm.value;
      this.memberService.create(member).subscribe({
        next: (data) => {
          console.log('Member created successfully', data);
          this._router.navigate([`/member/list`]);
        },
        error: (err) => {
          console.error('Error creating member', err);
        }
      });
    }
  }

}
