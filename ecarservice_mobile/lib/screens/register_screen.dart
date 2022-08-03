import 'dart:io';
import 'dart:io' as Io;
import 'dart:typed_data';
import 'dart:ui';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutterv1/screens/login_screen.dart';
import 'package:image_picker/image_picker.dart';
import 'package:provider/provider.dart';
import 'package:flutter/foundation.dart';
import '../main.dart';
import '../model/requests/user_insert_request.dart';
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
      //TextEditingController _imageController = TextEditingController();
      final _formKey = GlobalKey<FormState>();

      String? imageString;
      File? image;
     
      @override void initState() {
        setState(() {});
        super.initState();
      }

      Future pickImage() async {
        final image = await ImagePicker().pickImage(source: ImageSource.gallery);

        debugPrint(image.toString());


        if(image==null) return;

        final imageTemp = File(image.path);
        Uint8List bytes = await image.readAsBytes();
        ByteData.view(bytes.buffer);
        var x = base64String(bytes);

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
                          await Navigator.pushNamed(context, LoginScreen.routeName),
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
              )
              );
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
              margin: const EdgeInsets.only(top: 10),
              decoration: const BoxDecoration(
                image: DecorationImage(
                  image: AssetImage('assets/images/background.png'),
                  fit: BoxFit.fill,
                )),
              child: Center(
                        child: Container(  
                          margin: EdgeInsets.only(top: 160),
                          child: const Text("Register", 
                          style:TextStyle(color: Colors.cyan, fontSize: 40, fontWeight: FontWeight.bold),)),
                      ),
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
                  gradient: const LinearGradient(
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
            Center(child: Text("Picture is required field", style: TextStyle(color: Colors.red),)),
            Padding(padding: const EdgeInsets.all(50),
            child: Form(
              key: _formKey,
              autovalidateMode: AutovalidateMode.onUserInteraction,
              child: Column(children: [
               Container(
                padding: const EdgeInsets.all(10),
                child: TextFormField(
                validator: (value)
                  {
                    if(value!.isEmpty)
                    {
                      return "Required field!";
                    }
                  },
                  decoration: const InputDecoration(
                   labelText: "FirstName",
                   labelStyle: TextStyle(
                    color: Colors.cyan,
                   ),
                   enabledBorder: OutlineInputBorder(
                    borderSide: BorderSide(width: 1, color: Colors.cyan)
                   )
                   ),
                   controller: _firstNameController,
                ),
              ),
              Container(
                padding: const EdgeInsets.all(10),
                child: TextFormField(
                  validator: (value)
                  {
                    if(value!.isEmpty)
                    {
                      return "Required field!";
                    }
                  },
                  decoration: const InputDecoration(
                   labelText: "Last name",
                   labelStyle: TextStyle(
                    color: Colors.cyan
                   ),
                   enabledBorder: OutlineInputBorder(
                    borderSide: BorderSide(width: 1, color: Colors.cyan)
                   )),
                   controller: _lastNameController,
                ),
              ),
               Container(
                padding: const EdgeInsets.all(10),
                child: TextFormField(
                validator: (value)
                {
                    if(value!.isEmpty)
                    {
                      return "Required field!";
                    }
                },
                  decoration: const InputDecoration(
                   labelText: "Email",
                   labelStyle: TextStyle(
                    color: Colors.cyan
                   ),
                   enabledBorder: OutlineInputBorder(
                    borderSide: BorderSide(width: 1, color: Colors.cyan)
                   )),
                   controller: _emailController,
                ),
              ),
               Container(
                padding: const EdgeInsets.all(10),
                child: TextFormField(
                validator: (value)
                  {
                    if(value!.isEmpty)
                    {
                      return "Required field!";
                    }
                  },
                  decoration: const InputDecoration(
                   labelText: "Username",
                   labelStyle: TextStyle(
                    color: Colors.cyan
                   ),
                   enabledBorder: OutlineInputBorder(
                    borderSide: BorderSide(width: 1, color: Colors.cyan)
                   )),
                   controller: _userNameController,
                ),
              ),
               Container(
                padding: const EdgeInsets.all(10),
                child: TextFormField(
                obscureText: true,
                validator: (value)
                  {
                     if(value!.isEmpty)
                    {
                      return "Required field!";
                    }
                  },
                  decoration: const InputDecoration(
                   labelText: "Password",
                   labelStyle: TextStyle(
                    color: Colors.cyan
                   ),
                   enabledBorder: OutlineInputBorder(
                    borderSide: BorderSide(width: 1, color: Colors.cyan)
                   )),
                   controller: _passwordController,
                ),
              ),
               Container(
                padding: const EdgeInsets.all(10),
                child: TextFormField(
                obscureText: true,
                validator: (value)
                    {
                    if(value!.isEmpty)
                    {
                       return "Required field!";
                    }
                    },
                  decoration: const InputDecoration(
                   labelText: "Password confirmation",
                   labelStyle: TextStyle(
                    color: Colors.cyan
                   ),
                   enabledBorder: OutlineInputBorder(
                    borderSide: BorderSide(width: 1, color: Colors.cyan)
                   )),
                   controller: _passwordConfirmationController,
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
                    if(_formKey.currentState!.validate()) {
                      register();
                    }
                  },
                  child: const Center(child: Text("Register")),
                ),
            ),
             
            ],),),
        ),
          ],
        ),
      ),
      ),  
    );
       }
  }