

import '../model/user.dart';
import 'base_provider.dart';

class UserProvider extends BaseProvider<User>{
  UserProvider() : super("User");

  @override 
  User fromJson(data){

    return User();
  }
}