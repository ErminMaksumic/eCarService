import 'dart:convert';
import 'package:flutter/foundation.dart';
import '../model/user.dart';
import '../utils/user.dart';
import 'base_provider.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("User");

  @override
  User fromJson(data) {
    return User.fromJson(data);
  }

  Future<User?> login() async {
    var url = Uri.parse("$baseUrl/login");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("An error occured!");
    }
  }

  Future<User?> register(dynamic request) async {
    var url = Uri.parse("$baseUrl");

    Map<String, String> headers = {"Content-Type": "application/json"};
    var jsonRequest = jsonEncode(request);
    var response = await http!.post(url, headers: headers, body: jsonRequest);

    if (response.statusCode == 400) {
      var body = jsonDecode(response.body);
      var errMsg = body['errors']['Error message'];
      throw Exception(errMsg.toString());
    }

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      return null;
    }
  }

  Future<User?> changeProfile(dynamic request) async {
    var url = Uri.parse("$baseUrl/changePassword/${UserLogin.user!.userId}");

    Map<String, String> headers = createHeaders();
    var jsonRequest = jsonEncode(request);
    var response =
        await http!.put(url, headers: headers, body: jsonEncode(request));

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      return null;
    }
  }
}
