import 'package:json_annotation/json_annotation.dart';
part 'additionalService.g.dart';

@JsonSerializable()
class AdditionalService {
  int? additionalServiceId;
  String? name;
  String? description;
  double? price;

  AdditionalService() {}

  factory AdditionalService.fromJson(Map<String, dynamic> json) =>
      _$AdditionalServiceFromJson(json);

  /// Connect the generated [_$OfferToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$AdditionalServiceToJson(this);
}
