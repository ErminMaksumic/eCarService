import 'dart:io';
import 'dart:typed_data';
import 'dart:ui';
import 'package:flutterv1/model/user.dart';
import 'package:flutterv1/screens/user/login_screen.dart';
import "package:flutterv1/utils/user.dart";
import 'package:flutter/material.dart';
import 'package:flutterv1/widgets/master_screen.dart';
import 'package:image_picker/image_picker.dart';
import 'package:provider/provider.dart';
import '../../providers/user_provider.dart';
import '../../utils/util.dart';

class ProfileScreen extends StatefulWidget {
  static const String routeName = "/profile";
  const ProfileScreen({Key? key}) : super(key: key);

  @override
  State<ProfileScreen> createState() => _ProfileScreenState();
}

class _ProfileScreenState extends State<ProfileScreen> {
  //final TextEditingController _oldPassword = TextEditingController();
  final TextEditingController _newPassword = TextEditingController();
  final TextEditingController _newPasswordConfirmation =
      TextEditingController();
  late UserProvider _userProvider;
  final _formKey = GlobalKey<FormState>();
  String? currentPicture = UserLogin.user!.image;
  String? imageString;
  File? image;

  @override
  Widget build(BuildContext context) {
    _userProvider = Provider.of(context, listen: false);

    return MasterScreenWidget(
        index: 2,
        child: Column(
          children: [
            Container(
              margin: const EdgeInsets.only(top: 10),
              child: const Text(
                "Change your image and password",
                style: TextStyle(
                  color: Colors.cyan,
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            Container(
              width: 300,
              margin: const EdgeInsets.only(top: 10),
              child: Stack(
                children: [
                  Container(
                    height: 250,
                    width: 500,
                    child: Column(
                      children: [
                        Container(
                            height: 250,
                            width: 300,
                            child: this.image == null
                                ? imageFromBase64String(currentPicture!)
                                : Image.file(
                                    image!,
                                  )),
                      ],
                    ),
                  ),
                ],
              ),
            ),
            Container(
              height: 40,
              margin: const EdgeInsets.fromLTRB(50, 20, 50, 0),
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10),
                  gradient:
                      const LinearGradient(colors: [Colors.cyan, Colors.blue])),
              child: InkWell(
                onTap: () async {
                  pickImage();
                },
                child: const Center(child: Text("Select the new picture")),
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
                      padding: const EdgeInsets.all(10),
                      decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(10)),
                      child: TextFormField(
                        obscureText: true,
                        controller: _newPassword,
                        decoration: const InputDecoration(
                            border: InputBorder.none,
                            hintText: "New password",
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
                          if (_newPassword.text.isNotEmpty &&
                              _newPasswordConfirmation.text.isEmpty) {
                            return "Required field!";
                          }
                        },
                        controller: _newPasswordConfirmation,
                        decoration: const InputDecoration(
                            border: InputBorder.none,
                            hintText: "Password confirmation",
                            hintStyle: TextStyle(color: Colors.cyan)),
                      ),
                    ),
                  ],
                ),
              ),
            ),
            Container(
                height: 50,
                margin: const EdgeInsets.fromLTRB(45, 0, 45, 0),
                decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(10),
                    gradient: const LinearGradient(
                        colors: [Colors.cyan, Colors.red])),
                child: InkWell(
                  onTap: () async {
                    try {
                      await _userProvider.changeProfile({
                        'password': _newPassword.text,
                        'passwordConfirmation': _newPasswordConfirmation.text,
                        'image': imageString,
                      });
                      Navigator.pop(context);

                      showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                                title: const Text("Success"),
                                content:
                                    const Text("Profile successfully edited!"),
                                actions: [
                                  TextButton(
                                      onPressed: () async => {
                                            await Navigator.popAndPushNamed(
                                                context, LoginScreen.routeName)
                                          },
                                      child: const Text("Ok"))
                                ],
                              ));
                    } on Exception catch (e) {
                      showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                                title: const Text("Profile change failed"),
                                content: const Text("Check field inputs"),
                                actions: [
                                  TextButton(
                                    child: const Text("Ok"),
                                    onPressed: () => Navigator.pop(context),
                                  )
                                ],
                              ));
                    }
                  },
                  child: const Center(child: Text("Change")),
                )),
          ],
        ));
  }

  Future pickImage() async {
    final image = await ImagePicker().pickImage(source: ImageSource.gallery);

    debugPrint(image.toString());

    if (image == null) return;

    final imageTemp = File(image.path);
    Uint8List bytes = await image.readAsBytes();
    ByteData.view(bytes.buffer);
    var x = base64String(bytes);

    setState(() {
      this.image = imageTemp;
      this.imageString = x;
    });
  }
}
