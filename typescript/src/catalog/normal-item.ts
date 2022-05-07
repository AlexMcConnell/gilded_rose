import { Range, Gradient, DecayEngine } from "../decay-engine";

const ageRate = -1;

const quality: Range = {
  min: 0,
  max: Infinity,
};

const decay: Gradient = [
  { gt: 0, lte: Infinity, rate: -1 },
  { gt: -Infinity, lte: 0, rate: -2 },
];

export const NormalItem = new DecayEngine(ageRate, quality, decay);
