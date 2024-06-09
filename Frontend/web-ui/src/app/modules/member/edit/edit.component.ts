import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Member } from '../member.model';
import { MemberService } from '../member.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  pageParentLink = 'Member';
  pageTitle = 'Edit Member';
  editMemberForm!: FormGroup;
  member!: Member; // added ! to make ensure about it it not undefined

  constructor(
    private fb: FormBuilder,
    private memberService: MemberService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {

    const memberId = this.route.snapshot.paramMap.get('id');
    if(memberId){
      this.createForm(memberId);
      this.memberService.get(memberId).subscribe((data: Member) => {
        this.member = data;
        this.populateForm();
      });
    }
  }

  createForm(id: string): void {
    this.editMemberForm = this.fb.group({
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: [''],
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
      id: [id]
    });
  }

  populateForm(): void {
    this.editMemberForm.patchValue(this.member);
  }

  onSubmit(): void {
    if (this.editMemberForm.valid) {
      this.memberService.update(this.member.id, this.editMemberForm.value).subscribe(() => {
        this.router.navigate(['/member/list']);
      });
    }
  }

}
