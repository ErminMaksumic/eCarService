import 'package:json_annotation/json_annotation.dart';
part 'user_update_request.g.dart';

@JsonSerializable()

class UserUpdateRequest {
  String? password;
  String? passwordConfirmation;
  String? image;

  UserUpdateRequest();

  factory UserUpdateRequest.fromJson(Map<String, dynamic> json) => _$UserUpdateRequestFromJson(json);

  /// Connect the generated [_$UserInsertRequestToJson function to the `toJson` method.
  Map<String, dynamic> toJson() => _$UserUpdateRequestToJson(this);

}