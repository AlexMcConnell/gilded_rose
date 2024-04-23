pub struct Item {
    pub name: String,
    pub days_remaining: i32,
    pub quality: i32,
}

impl Item {
    pub fn new(name: &str, days_remaining: i32, quality: i32) -> Item {
        Item {
            name: name.to_string(),
            days_remaining,
            quality,
        }
    }
}