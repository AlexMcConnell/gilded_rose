use gilded_rose::{gilded_rose::GildedRose, item::Item};

mod normal_item {
    use super::*;

    #[test]
    fn before_sell_date() {
        let mut items = vec![Item::new("randomstring", 5, 10)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 4);
        assert_eq!(items[0].quality, 9);
    }

    #[test]
    fn with_min_quality() {
        let mut items = vec![Item::new("randomstring", 5, 0)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 4);
        assert_eq!(items[0].quality, 0);
    }

    #[test]
    fn on_sell_date() {
        let mut items = vec![Item::new("randomstring", 0, 10)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -1);
        assert_eq!(items[0].quality, 8);
    }

    #[test]
    fn on_sell_date_with_min_quality() {
        let mut items = vec![Item::new("randomstring", 0, 0)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -1);
        assert_eq!(items[0].quality, 0);
    }

    #[test]
    fn on_sell_date_near_min_quality() {
        let mut items = vec![Item::new("randomstring", 0, 1)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -1);
        assert_eq!(items[0].quality, 0);
    }

    #[test]
    fn after_sell_date() {
        let mut items = vec![Item::new("randomstring", -10, 10)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -11);
        assert_eq!(items[0].quality, 8);
    }

    #[test]
    fn after_sell_date_with_min_quality() {
        let mut items = vec![Item::new("randomstring", -10, 0)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -11);
        assert_eq!(items[0].quality, 0);
    }

    #[test]
    fn after_sell_date_near_min_quality() {
        let mut items = vec![Item::new("randomstring", -10, 1)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -11);
        assert_eq!(items[0].quality, 0);
    }
}

mod aged_cheddar {
    use super::*;

    #[test]
    fn before_sell_date() {
        let mut items = vec![Item::new("Aged Cheddar", 5, 10)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 4);
        assert_eq!(items[0].quality, 11);
    }

    #[test]
    fn with_max_quality() {
        let mut items = vec![Item::new("Aged Cheddar", 5, 50)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 4);
        assert_eq!(items[0].quality, 50);
    }

    #[test]
    fn on_sell_date() {
        let mut items = vec![Item::new("Aged Cheddar", 0, 10)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -1);
        assert_eq!(items[0].quality, 12);
    }

    #[test]
    fn on_sell_date_with_max_quality() {
        let mut items = vec![Item::new("Aged Cheddar", 0, 50)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -1);
        assert_eq!(items[0].quality, 50);
    }

    #[test]
    fn on_sell_date_near_max_quality() {
        let mut items = vec![Item::new("Aged Cheddar", 0, 49)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -1);
        assert_eq!(items[0].quality, 50);
    }

    #[test]
    fn after_sell_date() {
        let mut items = vec![Item::new("Aged Cheddar", -10, 10)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -11);
        assert_eq!(items[0].quality, 12);
    }

    #[test]
    fn after_sell_date_with_max_quality() {
        let mut items = vec![Item::new("Aged Cheddar", -10, 50)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -11);
        assert_eq!(items[0].quality, 50);
    }

    #[test]
    fn after_sell_date_near_max_quality() {
        let mut items = vec![Item::new("Aged Cheddar", -10, 49)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -11);
        assert_eq!(items[0].quality, 50);
    }
}

mod hammer {
    use super::*;

    #[test]
    fn before_sell_date() {
        let mut items = vec![Item::new("Hammer", 5, 40)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 5);
        assert_eq!(items[0].quality, 40);
    }

    #[test]
    fn on_sell_date() {
        let mut items = vec![Item::new("Hammer", 0, 40)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 0);
        assert_eq!(items[0].quality, 40);
    }

    #[test]
    fn after_sell_date() {
        let mut items = vec![Item::new("Hammer", -10, 40)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -10);
        assert_eq!(items[0].quality, 40);
    }
}

mod concert_tickets {
    use super::*;
    #[test]
    fn long_before_sell_date() {
        let mut items = vec![Item::new("Concert Tickets", 11, 10)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 10);
        assert_eq!(items[0].quality, 11);
    }

    #[test]
    fn long_before_sell_date_at_max_quality() {
        let mut items = vec![Item::new("Concert Tickets", 11, 50)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 10);
        assert_eq!(items[0].quality, 50);
    }

    #[test]
    fn medium_close_to_sell_date_upper_bound() {
        let mut items = vec![Item::new("Concert Tickets", 10, 10)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 9);
        assert_eq!(items[0].quality, 12);
    }

    #[test]
    fn medium_close_to_sell_date_upper_bound_at_max_quality() {
        let mut items = vec![Item::new("Concert Tickets", 10, 50)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 9);
        assert_eq!(items[0].quality, 50);
    }

    #[test]
    fn medium_close_to_sell_date_upper_bound_near_max_quality() {
        let mut items = vec![Item::new("Concert Tickets", 10, 49)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 9);
        assert_eq!(items[0].quality, 50);
    }

    #[test]
    fn medium_close_to_sell_date_lower_bound() {
        let mut items = vec![Item::new("Concert Tickets", 6, 10)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 5);
        assert_eq!(items[0].quality, 12);
    }

    #[test]
    fn medium_close_to_sell_date_lower_bound_at_max_quality() {
        let mut items = vec![Item::new("Concert Tickets", 6, 50)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 5);
        assert_eq!(items[0].quality, 50);
    }

    #[test]
    fn medium_close_to_sell_date_lower_bound_near_max_quality() {
        let mut items = vec![Item::new("Concert Tickets", 6, 49)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 5);
        assert_eq!(items[0].quality, 50);
    }

    #[test]
    fn very_close_to_sell_date_upper_bound() {
        let mut items = vec![Item::new("Concert Tickets", 5, 10)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 4);
        assert_eq!(items[0].quality, 13);
    }

    #[test]
    fn very_close_to_sell_date_upper_bound_at_max_quality() {
        let mut items = vec![Item::new("Concert Tickets", 5, 50)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 4);
        assert_eq!(items[0].quality, 50);
    }

    #[test]
    fn very_close_to_sell_date_upper_bound_near_max_quality() {
        let mut items = vec![Item::new("Concert Tickets", 5, 48)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 4);
        assert_eq!(items[0].quality, 50);
    }

    #[test]
    fn very_close_to_sell_date_lower_bound() {
        let mut items = vec![Item::new("Concert Tickets", 1, 10)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 0);
        assert_eq!(items[0].quality, 13);
    }

    #[test]
    fn very_close_to_sell_date_lower_bound_at_max_quality() {
        let mut items = vec![Item::new("Concert Tickets", 1, 50)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 0);
        assert_eq!(items[0].quality, 50);
    }

    #[test]
    fn very_close_to_sell_date_lower_bound_near_max_quality() {
        let mut items = vec![Item::new("Concert Tickets", 1, 48)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, 0);
        assert_eq!(items[0].quality, 50);
    }

    #[test]
    fn on_sell_date() {
        let mut items = vec![Item::new("Concert Tickets", 0, 10)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -1);
        assert_eq!(items[0].quality, 0);
    }

    #[test]
    fn after_sell_date() {
        let mut items = vec![Item::new("Concert Tickets", -10, 10)];
        let gilded_rose = GildedRose::new();

        gilded_rose.process_end_of_day(&mut items);

        assert_eq!(items[0].days_remaining, -11);
        assert_eq!(items[0].quality, 0);
    }
}
