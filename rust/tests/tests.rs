#[cfg(test)]
mod tests {

    mod normal_item {

        #[test]
        fn before_sell_date() {
            let mut item = rust::Item { name: "randomstring".to_string(), days_remaining: 5, quality: 10 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 4);
            assert_eq!(item.quality, 9);
        }

        #[test]
        fn with_min_quality() {
            let mut item = rust::Item { name: "randomstring".to_string(), days_remaining: 5, quality: 0 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 4);
            assert_eq!(item.quality, 0);
        }
        
        #[test]
        fn on_sell_date() {
            let mut item = rust::Item { name: "randomstring".to_string(), days_remaining: 0, quality: 10 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -1);
            assert_eq!(item.quality, 8);
        }
        
        #[test]
        fn on_sell_date_with_min_quality() {
            let mut item = rust::Item { name: "randomstring".to_string(), days_remaining: 0, quality: 0 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -1);
            assert_eq!(item.quality, 0);
        }
        
        #[test]
        fn on_sell_date_near_min_quality() {
            let mut item = rust::Item { name: "randomstring".to_string(), days_remaining: 0, quality: 1 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -1);
            assert_eq!(item.quality, 0);
        }
        
        #[test]
        fn after_sell_date() {
            let mut item = rust::Item { name: "randomstring".to_string(), days_remaining: -10, quality: 10 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -11);
            assert_eq!(item.quality, 8);
        }
        
        #[test]
        fn after_sell_date_with_min_quality() {
            let mut item = rust::Item { name: "randomstring".to_string(), days_remaining: -10, quality: 0 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -11);
            assert_eq!(item.quality, 0);
        }
        
        #[test]
        fn after_sell_date_near_min_quality() {
            let mut item = rust::Item { name: "randomstring".to_string(), days_remaining: -10, quality: 1 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -11);
            assert_eq!(item.quality, 0);
        }

    }

    mod aged_cheddar {

        #[test]
        fn before_sell_date() {
            let mut item = rust::Item { name: "Aged Cheddar".to_string(), days_remaining: 5, quality: 10 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 4);
            assert_eq!(item.quality, 11);
        }

        #[test]
        fn with_max_quality() {
            let mut item = rust::Item { name: "Aged Cheddar".to_string(), days_remaining: 5, quality: 50 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 4);
            assert_eq!(item.quality, 50);
        }
        
        #[test]
        fn on_sell_date() {
            let mut item = rust::Item { name: "Aged Cheddar".to_string(), days_remaining: 0, quality: 10 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -1);
            assert_eq!(item.quality, 12);
        }
        
        #[test]
        fn on_sell_date_with_max_quality() {
            let mut item = rust::Item { name: "Aged Cheddar".to_string(), days_remaining: 0, quality: 50 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -1);
            assert_eq!(item.quality, 50);
        }
        
        #[test]
        fn on_sell_date_near_max_quality() {
            let mut item = rust::Item { name: "Aged Cheddar".to_string(), days_remaining: 0, quality: 49 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -1);
            assert_eq!(item.quality, 50);
        }
        
        #[test]
        fn after_sell_date() {
            let mut item = rust::Item { name: "Aged Cheddar".to_string(), days_remaining: -10, quality: 10 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -11);
            assert_eq!(item.quality, 12);
        }
        
        #[test]
        fn after_sell_date_with_max_quality() {
            let mut item = rust::Item { name: "Aged Cheddar".to_string(), days_remaining: -10, quality: 50 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -11);
            assert_eq!(item.quality, 50);
        }
        
        #[test]
        fn after_sell_date_near_max_quality() {
            let mut item = rust::Item { name: "Aged Cheddar".to_string(), days_remaining: -10, quality: 49 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -11);
            assert_eq!(item.quality, 50);
        }

    }

    mod hammer {

        #[test]
        fn before_sell_date() {
            let mut item = rust::Item { name: "Hammer".to_string(), days_remaining: 5, quality: 40 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 5);
            assert_eq!(item.quality, 40);
        }

        #[test]
        fn on_sell_date() {
            let mut item = rust::Item { name: "Hammer".to_string(), days_remaining: 0, quality: 40 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 0);
            assert_eq!(item.quality, 40);
        }
        
        #[test]
        fn after_sell_date() {
            let mut item = rust::Item { name: "Hammer".to_string(), days_remaining: -10, quality: 40 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -10);
            assert_eq!(item.quality, 40);
        }

    }

    mod concert_tickets {

        #[test]
        fn long_before_sell_date() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 11, quality: 10 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 10);
            assert_eq!(item.quality, 11);
        }

        #[test]
        fn long_before_sell_date_at_max_quality() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 11, quality: 50 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 10);
            assert_eq!(item.quality, 50);
        }
        
        #[test]
        fn medium_close_to_sell_date_upper_bound() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 10, quality: 10 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 9);
            assert_eq!(item.quality, 12);
        }
        
        #[test]
        fn medium_close_to_sell_date_upper_bound_at_max_quality() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 10, quality: 50 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 9);
            assert_eq!(item.quality, 50);
        }
        
        #[test]
        fn medium_close_to_sell_date_upper_bound_near_max_quality() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 10, quality: 49 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 9);
            assert_eq!(item.quality, 50);
        }
        
        #[test]
        fn medium_close_to_sell_date_lower_bound() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 6, quality: 10 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 5);
            assert_eq!(item.quality, 12);
        }
        
        #[test]
        fn medium_close_to_sell_date_lower_bound_at_max_quality() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 6, quality: 50 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 5);
            assert_eq!(item.quality, 50);
        }
        
        #[test]
        fn medium_close_to_sell_date_lower_bound_near_max_quality() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 6, quality: 49 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 5);
            assert_eq!(item.quality, 50);
        }

        #[test]
        fn very_close_to_sell_date_upper_bound() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 5, quality: 10 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 4);
            assert_eq!(item.quality, 13);
        }

        #[test]
        fn very_close_to_sell_date_upper_bound_at_max_quality() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 5, quality: 50 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 4);
            assert_eq!(item.quality, 50);
        }

        #[test]
        fn very_close_to_sell_date_upper_bound_near_max_quality() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 5, quality: 48 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 4);
            assert_eq!(item.quality, 50);
        }

        #[test]
        fn very_close_to_sell_date_lower_bound() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 1, quality: 10 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 0);
            assert_eq!(item.quality, 13);
        }

        #[test]
        fn very_close_to_sell_date_lower_bound_at_max_quality() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 1, quality: 50 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 0);
            assert_eq!(item.quality, 50);
        }

        #[test]
        fn very_close_to_sell_date_lower_bound_near_max_quality() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 1, quality: 48 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, 0);
            assert_eq!(item.quality, 50);
        }

        #[test]
        fn on_sell_date() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: 0, quality: 10 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -1);
            assert_eq!(item.quality, 0);
        }

        #[test]
        fn after_sell_date() {
            let mut item = rust::Item { name: "Concert Tickets".to_string(), days_remaining: -10, quality: 10 };
            rust::process_end_of_day(vec![&mut item]);
            assert_eq!(item.days_remaining, -11);
            assert_eq!(item.quality, 0);
        }

    }
}