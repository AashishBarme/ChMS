// member.model.ts
export interface Member {
  id: string;
  firstName: string;
  middleName?: string;
  lastName: string;
  email: string;
  phoneNumber?: string;
  secondaryPhoneNumber?: string;
  birthDate: string;
  gender: string;
  occupation: string;
  permanentAddress: string;
  temporaryAddress: string;
  baptizedDate: string;
  membershipDate?: string;
  photo?: string;
}

// member.model.ts
export interface ListMember {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  gender: string;
  phoneNumber: string;
  createdDate: Date;
  updatedDate: Date;
}
