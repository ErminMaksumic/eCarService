import 'package:json_annotation/json_annotation.dart';
part 'rating.g.dart';

@JsonSerializable()
class Rating {
  int? ratingId;
  int? rate;
  String? comment;
  int? offerId;
  int? userId;

  Rating() {}

  factory Rating.fromJson(Map<String, dynamic> json) => _$RatingFromJson(json);

  /// Connect the generated [_$RatingToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$RatingToJson(this);
}
