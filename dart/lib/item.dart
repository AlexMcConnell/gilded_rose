class Item {
  String name;
  int daysRemaining;
  int quality;

  Item({
    this.name,
    this.daysRemaining,
    this.quality,
  });

  String toString() => '$name, $daysRemaining, $quality';
}
