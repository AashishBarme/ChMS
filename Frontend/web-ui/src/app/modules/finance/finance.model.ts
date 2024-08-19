import { Helpers } from "src/app/helpers/Helpers";

// src/app/models/inventory.model.ts
export class Income {
  id: number = 0;
  category: string = "";
  amount: number = 0;
  description?: string;
  date: string = "";
  memberId: number = 0;
}

export class FilterVm {
  limit: number = 20;
  offset: number = 0;
  name: string | null = "";
  code: string | null = "";
}

export class AddIncome
{
  date: string = "";
  income: Income[] = [];
}


