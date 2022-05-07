import { Range, Gradient, DecayEngine } from "../decay-engine";

const ageRate = -1;

const quality: Range = {
  min: 0,
  max: 50,
};

const decay: Gradient = [
  { gt: 9, lte: Infinity, rate: 1 },
  { gt: 4, lte: 9, rate: 2 },
  { gt: -1, lte: 4, rate: 3 },
  { gt: -Infinity, lte: -1, rate: -Infinity },
];

export const ConcertTickets = new DecayEngine(ageRate, quality, decay);
