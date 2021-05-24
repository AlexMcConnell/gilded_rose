class Item
    attr_accessor :name, :days_remaining, :quality

    def initialize(name:, days_remaining:, quality:)
      @name = name
      @days_remaining = days_remaining
      @quality = quality
    end
end
