// src/app/models/inventory.model.ts
export interface Document {
  id: number;
  name: string;
  size: string;
  path: string;
  description?: string;
  file?: string;
  type?: string;
  createdDate?: string;
}

export class FilterVm {
  limit: number = 20;
  offset: number = 0;
  name: string | null = "";
  code: string | null = "";
}
