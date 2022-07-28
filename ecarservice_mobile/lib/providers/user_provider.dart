import 'dart:convert';
import 'package:flutter/foundation.dart';
import '../model/user.dart';
import 'base_provider.dart';

class UserProvider extends BaseProvider<User>{
  UserProvider() : super("User");

  @override 
  User fromJson(data){

    return User.fromJson(data);
  }

    Future<User?> login() async {
    var url = Uri.parse("$baseUrl/login");

    Map<String, String> headers = createHeaders();

    var response = await http!.get(url, headers: headers);

    if (isValidResponseCode(response)) {
      debugPrint('response: ${response.body}');
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

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      return null;
    }
  }
}