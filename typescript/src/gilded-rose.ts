import { Catalog } from "./catalog";
import { Item } from "./item";

export class GildedRose {
  processEndOfDay(items: Item[]) {
    for (const item of items) {
      const engine = Catalog[item.name] || Catalog.Default;

      engine.process(item);
    }
  }
}
