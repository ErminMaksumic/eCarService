import 'package:json_annotation/json_annotation.dart';
part 'carService.g.dart';

@JsonSerializable()
class CarService {
  int? carServiceId;
  String? name;
  String? address;
  DateTime? dateCreated;
  String? phoneNumber;
  int? userId;

  CarService() {}

  factory CarService.fromJson(Map<String, dynamic> json) =>
      _$CarServiceFromJson(json);

  /// Connect the generated [_$CarServiceToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$CarServiceToJson(this);
}
