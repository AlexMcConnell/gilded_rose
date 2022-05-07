import { Range, Gradient, DecayEngine } from "../decay-engine";

const ageRate = 0;

const quality: Range = {
  min: 0,
  max: Infinity,
};

const decay: Gradient = [{ gt: -Infinity, lte: Infinity, rate: 0 }];

export const Hammer = new DecayEngine(ageRate, quality, decay);
