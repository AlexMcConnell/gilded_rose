import { Item } from "./item";

export type Range = {
  min: number;
  max: number;
};

export type BoundedRate = {
  gt: number;
  lte: number;
  rate: number;
};

export type Gradient = Array<BoundedRate>;

export class DecayEngine {
  ageRate: number;
  decay: Gradient;
  quality: Range;

  constructor(ageRate: number, quality: Range, decay: Gradient) {
    this.ageRate = ageRate;
    this.decay = decay;
    this.quality = quality;
  }

  process(item: Item) {
    item.daysRemaining += this.ageRate;

    const gradient = this.decay.find((rate) => {
      const days = item.daysRemaining;
      return days > rate.gt && days <= rate.lte;
    });

    if (!gradient) {
      throw new Error("no valid decay gradient found");
    }

    item.quality += gradient.rate;

    if (item.quality > this.quality.max) {
      item.quality = this.quality.max;
    } else if (item.quality < this.quality.min) {
      item.quality = this.quality.min;
    }
  }
}
