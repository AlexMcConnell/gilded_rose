/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.gildedrose;

/**
 *
 * @author Tovar
 */
public class PassesUpdater extends ItemUpdater {

    public PassesUpdater(Item original) {
        super(original);
    }

    @Override
    public void endOfDay() {
        item.sellIn--;
        int qualityChange = 1;
        if (item.sellIn < 0) {
            qualityChange = -1 * item.quality;
        } else if (item.sellIn < 5) {
            qualityChange *= 3;
        } else if (item.sellIn < 10) {
            qualityChange *= 2;
        }
        item.quality = Math.min(50, Math.max(0, item.quality + qualityChange));
    }
}
