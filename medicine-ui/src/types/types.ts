export interface Medicine {
  id: number;
  fullName: string;
  notes: string;
  expiryDate: string;
  quantity: number;
  price: number;
  brand: string;
}

export class MedicineForm implements Medicine {
  id: number = 0; // default value for new medicine
  fullName: string;
  notes: string;
  expiryDate: string;
  quantity: number;
  price: number;
  brand: string;

  constructor(fullName: string, notes: string, expiryDate: string, quantity: number, price: number, brand: string) {
    this.fullName = fullName;
    this.notes = notes;
    this.expiryDate = expiryDate;
    this.quantity = quantity;
    this.price = price;
    this.brand = brand;
  }
}