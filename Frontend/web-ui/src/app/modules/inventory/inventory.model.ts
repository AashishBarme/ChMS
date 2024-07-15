// src/app/models/inventory.model.ts
export interface Inventory {
  id: number;
  name: string;
  code: string;
  quantity: string;
  description?: string;
  image?: string;
  createdDate?: string;
}
