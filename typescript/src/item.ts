export class Item {
  name: string;
  quality: number;
  daysRemaining: number;

  constructor(name: string, daysRemaining: number, quality: number) {
    this.name = name;
    this.quality = quality;
    this.daysRemaining = daysRemaining;
  }
}
