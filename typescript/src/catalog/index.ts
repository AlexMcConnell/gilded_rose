import { DecayEngine } from "../decay-engine";
import { Hammer } from "./hammer";
import { RawMilk } from "./raw-milk";
import { NormalItem } from "./normal-item";
import { AgedCheddar } from "./aged-cheddar";
import { ConcertTickets } from "./concert-tickets";

export const Catalog: Record<string, DecayEngine> = {
  Default: NormalItem,
  Hammer: Hammer,
  "Raw Milk": RawMilk,
  "Aged Cheddar": AgedCheddar,
  "Concert Tickets": ConcertTickets,
};
