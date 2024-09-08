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
  middleName: string;
  email: string;
  gender: string;
  phoneNumber: string;
  createdDate: Date;
  updatedDate: Date;
  photo?: string;
}

export class FilterVm {
  limit: number = 20;
  offset: number = 0;
  name: string | null = "";
  phoneNumber: string | null = "";
  gender : string | null = "";
}

