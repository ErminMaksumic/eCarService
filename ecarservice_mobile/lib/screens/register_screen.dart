

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../providers/user_provider.dart';

class RegistrationScreen extends StatefulWidget {
  static const String routeName = "/register";
  const RegistrationScreen({Key? key}) : super(key: key);

  @override
  State<RegistrationScreen> createState() => _RegistrationScreenState();
}

      class _RegistrationScreenState extends State<RegistrationScreen> {
      late UserProvider _userProvider;
     
      @override void initState() {
      super.initState();
      }

       @override
       Widget build(BuildContext context) {
      _userProvider = Provider.of<UserProvider>(context, listen: false);
      return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              height: 350,
              decoration: const BoxDecoration(
                image: DecorationImage(
                  image: AssetImage('assets/images/background.png'),
                  fit: BoxFit.fill
                )),
            )
          ],
        ),
      )
    );
       }



  }