import "package:flutterv1/utils/user.dart";
import 'package:flutter/material.dart';
import 'package:flutterv1/screens/user/register_screen.dart';
import 'package:provider/provider.dart';
import '../../providers/user_provider.dart';
import '../../utils/util.dart';
import '../offers/offers_screen.dart';

class LoginScreen extends StatelessWidget {
  static const String routeName = "/login";
  final TextEditingController _usernameController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  late UserProvider _userProvider;
  final _formKey = GlobalKey<FormState>();
  LoginScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    //_userProvider = context.read<UserProvider>();
    _userProvider = Provider.of(context, listen: false);
    return Scaffold(
        appBar: AppBar(
          title: const Text("Login"),
        ),
        body: SingleChildScrollView(
          child: Column(
            children: [
              Container(
                height: 350,
                decoration: const BoxDecoration(
                    image: DecorationImage(
                        image: AssetImage('assets/images/background.png'),
                        fit: BoxFit.fill)),
                child: Stack(
                  children: [
                    Container(
                      margin: EdgeInsets.only(top: 280),
                      child: const Center(
                        child: Center(
                            child: Text(
                          "Login",
                          style: TextStyle(
                              color: Colors.cyan,
                              fontSize: 40,
                              fontWeight: FontWeight.bold),
                        )),
                      ),
                    )
                  ],
                ),
              ),
              Padding(
                padding: const EdgeInsets.all(50),
                child: Form(
                  key: _formKey,
                  autovalidateMode: AutovalidateMode.onUserInteraction,
                  child: Column(
                    children: [
                      Container(
                        padding: EdgeInsets.all(10),
                        decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(10)),
                        child: TextFormField(
                          validator: (value) {
                            if (value!.isEmpty) {
                              return "Required field!";
                            }
                          },
                          controller: _usernameController,
                          decoration: const InputDecoration(
                              border: InputBorder.none,
                              hintText: "Username",
                              hintStyle: TextStyle(color: Colors.cyan)),
                        ),
                      ),
                      Container(
                        padding: const EdgeInsets.all(10),
                        decoration: const BoxDecoration(
                            border: Border(
                                top: BorderSide(color: Colors.cyan),
                                bottom: BorderSide(color: Colors.cyan))),
                        child: TextFormField(
                          obscureText: true,
                          validator: (value) {
                            if (value!.isEmpty) {
                              return "Required field!";
                            }
                          },
                          controller: _passwordController,
                          decoration: const InputDecoration(
                              border: InputBorder.none,
                              hintText: "Password",
                              hintStyle: TextStyle(color: Colors.cyan)),
                        ),
                      ),
                    ],
                  ),
                ),
              ),
              Container(
                  height: 50,
                  margin: EdgeInsets.fromLTRB(45, 0, 45, 0),
                  decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(10),
                      gradient:
                          LinearGradient(colors: [Colors.cyan, Colors.blue])),
                  child: InkWell(
                    onTap: () async {
                      try {
                        if (_formKey.currentState!.validate()) {
                          Authorization.username = _usernameController.text;
                          Authorization.password = _passwordController.text;
                          UserLogin.user = await _userProvider.login();
                          Navigator.popAndPushNamed(
                              context, OfferListScreen.routeName);
                        }
                      } on Exception catch (e) {
                        showDialog(
                            context: context,
                            builder: (BuildContext context) => AlertDialog(
                                  title: Text("Login failed"),
                                  content:
                                      Text("Invalid username and/or password"),
                                  actions: [
                                    TextButton(
                                      child: Text("Ok"),
                                      onPressed: () => Navigator.pop(context),
                                    )
                                  ],
                                ));
                      }
                    },
                    child: Center(child: Text("Login")),
                  )),
              SizedBox(height: 20),
              Center(
                  child: InkWell(
                child: const Center(
                    child: Text(
                  "You are not registered? Click here!",
                  style: TextStyle(color: Colors.cyan),
                )),
                onTap: () {
                  Navigator.pop(context, RegistrationScreen.routeName);
                },
              )),
            ],
          ),
        ));
  }
}
