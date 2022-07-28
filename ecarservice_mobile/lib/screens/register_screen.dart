import 'dart:io';
import 'dart:io' as Io;
import 'dart:typed_data';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:provider/provider.dart';
import 'package:flutter/foundation.dart';
import '../main.dart';
import '../model/user_insert_request.dart';
import '../providers/user_provider.dart';
import '../utils/util.dart';

class RegistrationScreen extends StatefulWidget {
  static const String routeName = "/register";
  const RegistrationScreen({Key? key}) : super(key: key);

  @override
  State<RegistrationScreen> createState() => _RegistrationScreenState();
}

      class _RegistrationScreenState extends State<RegistrationScreen> {
      late UserProvider _userProvider;
      TextEditingController _firstNameController = TextEditingController();
      TextEditingController _lastNameController = TextEditingController();
      TextEditingController _emailController = TextEditingController();
      TextEditingController _userNameController = TextEditingController();
      TextEditingController _passwordController = TextEditingController();
      TextEditingController _passwordConfirmationController = TextEditingController();
      TextEditingController _imageController = TextEditingController();

      String? imageString;
      File? image;
     
      @override void initState() {
      super.initState();
      }

      Future pickImage() async {
        final image = await ImagePicker().pickImage(source: ImageSource.gallery);

        debugPrint(image.toString());


        if(image==null) return;

        final imageTemp = File(image.path);

        debugPrint(imageTemp.toString());

        Uint8List bytes = await image.readAsBytes();
        ByteData.view(bytes.buffer);

        var x = base64String(bytes);
        debugPrint(x);

        setState(() {
          this.image = imageTemp;
          this.imageString = x;
        } 
        );
      }

register() async {
    try {
      var request = UserInsertRequest();

      request.firstName = _firstNameController.text;
      request.lastName = _lastNameController.text;
      request.userName = _userNameController.text;
      request.email = _emailController.text;
      request.password = _passwordController.text;
      request.passwordConfirmation = _passwordConfirmationController.text;
      request.image = imageString;
      request.roleId = 3;
      var response = await _userProvider.register(request);

      showDialog(
          context: context,
          builder: (BuildContext context) => AlertDialog(
                title: Text("Success"),
                content: Text("You are registered as ${_userNameController.text}"),
                actions: [
                  TextButton(
                      onPressed: () async =>
                          await Navigator.pushNamed(context, MyApp.routeName),
                      child: Text("Ok"))
                ],
              ));
        } on Exception catch (e) {
        showDialog(
          context: context,
          builder: (BuildContext context) => AlertDialog(
                title: Text("Error"),
                content: Text(e.toString()),
                actions: [
                  TextButton(
                      onPressed: () => Navigator.pop(context),
                      child: Text("Ok"))
                ],
              ));
    }
  }
  
       @override
       Widget build(BuildContext context) {
      _userProvider = Provider.of<UserProvider>(context, listen: false);
      return Scaffold(
      body: SafeArea(
        child: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              height: 200,
              margin: EdgeInsets.only(top: 10),
              decoration: const BoxDecoration(
                image: DecorationImage(
                  image: AssetImage('assets/images/background.png'),
                  fit: BoxFit.fill,
                )),
            ),
            image!= null ? Image.file(
              image!,
              width: 160,
              height: 160,
                  fit: BoxFit.fill
            ) : 
            Container(
               height: 50,
                margin: EdgeInsets.fromLTRB(50, 20, 50, 0),
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10),
                  gradient: LinearGradient(
                    colors: [Colors.cyan, Colors.blue ]
                  )
                ),
              child: InkWell(
                  onTap: () async {
                    pickImage();
                  },
                  child: Center(child: Text("Select the picture")),
                ),
            ),
            Padding(padding: const EdgeInsets.all(50),
            child: Column(children: [
              Container(
                padding: EdgeInsets.all(10),
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10)
                ),
                child: TextField(
                  controller: _firstNameController,
                  

                  decoration: const InputDecoration(border: InputBorder.none, hintText: "FirstName", 
                  hintStyle: TextStyle(color: Colors.cyan)),
                ),
              ),
              Container(
                padding: const EdgeInsets.all(10),
                decoration: const BoxDecoration(
                  border: Border(top: BorderSide(color: Colors.cyan), bottom: BorderSide(color: Colors.cyan)
                  )
                ),

                child: TextField(
                   controller: _lastNameController,
                   decoration: InputDecoration(border: InputBorder.none, hintText: "LastName",
                   hintStyle: TextStyle(color: Colors.cyan)),
                ),
              ),
              Container(
                padding: const EdgeInsets.all(10),
                decoration: const BoxDecoration(
                  border: Border(top: BorderSide(color: Colors.cyan), bottom: BorderSide(color: Colors.cyan)
                  )
                ),

                child: TextField(
                   controller: _emailController,
                   decoration: InputDecoration(border: InputBorder.none, hintText: "Email",
                   hintStyle: TextStyle(color: Colors.cyan)),
                ),
              ),
              Container(
                padding: const EdgeInsets.all(10),
                decoration: const BoxDecoration(
                  border: Border(top: BorderSide(color: Colors.cyan), bottom: BorderSide(color: Colors.cyan)
                  )
                ),

                child: TextField(
                   controller: _userNameController,
                   decoration: InputDecoration(border: InputBorder.none, hintText: "UserName",
                   hintStyle: TextStyle(color: Colors.cyan)),
                ),
              ),
              Container(
                padding: const EdgeInsets.all(10),
                decoration: const BoxDecoration(
                  border: Border(top: BorderSide(color: Colors.cyan), bottom: BorderSide(color: Colors.cyan)
                  )
                ),

                child: TextField(
                   controller: _passwordController,
                   decoration: InputDecoration(border: InputBorder.none, hintText: "Password",
                   hintStyle: TextStyle(color: Colors.cyan)),
                ),
              ),
              Container(
                padding: const EdgeInsets.all(10),
                decoration: const BoxDecoration(
                  border: Border(top: BorderSide(color: Colors.cyan), bottom: BorderSide(color: Colors.cyan)
                  )
                ),

                child: TextField(
                   controller: _passwordConfirmationController,
                   decoration: const InputDecoration(border: InputBorder.none, hintText: "PasswordConfirmation",
                   hintStyle: TextStyle(color: Colors.cyan)),
                ),
              ),
               SizedBox(height: 20),
              Container(
               height: 50,
                margin: EdgeInsets.fromLTRB(50, 20, 50, 0),
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10),
                  gradient: const LinearGradient(
                    colors: [Colors.cyan, Colors.blue ]
                  )
                ),
              child: InkWell(
                  onTap: () async {
                   register();
                  },
                  child: const Center(child: Text("Register")),
                ),
            ),
             
            ],),),
          ],
        ),
      ),
      ),  
    );
       }
  }