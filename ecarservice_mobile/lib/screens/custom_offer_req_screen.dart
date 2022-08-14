import 'dart:io';
import 'dart:io' as Io;
import 'dart:typed_data';
import 'dart:ui';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutterv1/model/carService.dart';
import 'package:flutterv1/providers/car_service_provider.dart';
import 'package:flutterv1/providers/custom_offer_provider.dart';
import 'package:flutterv1/screens/login_screen.dart';
import 'package:flutterv1/screens/offer_details_screen.dart';
import 'package:flutterv1/screens/offers_screen.dart';
import 'package:flutterv1/utils/user.dart';
import 'package:image_picker/image_picker.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:flutter/foundation.dart';
import '../main.dart';
import '../model/requests/user_insert_request.dart';
import '../providers/user_provider.dart';
import '../utils/util.dart';
import '../widgets/master_screen.dart';

class CustomOfferReqScreen extends StatefulWidget {
  static const String routeName = "/customOfferRequest";
  const CustomOfferReqScreen({Key? key}) : super(key: key);

  @override
  State<CustomOfferReqScreen> createState() => _CustomOfferReqScreenState();
}

class _CustomOfferReqScreenState extends State<CustomOfferReqScreen> {
  UserProvider? _userProvider;
  CarServiceProvider? _carServiceProvider;
  CustomOfferRequestProvider? _customOfferReqProvider;
  List<CarService> carServices = [];
  int? selectedCarService;
  String? selectedDate;

  TextEditingController _nameController = TextEditingController();
  TextEditingController _descriptionController = TextEditingController();
  final _formKey = GlobalKey<FormState>();

  @override
  void initState() {
    setState(() {});
    super.initState();
    _carServiceProvider = context.read<CarServiceProvider>();
    _customOfferReqProvider = context.read<CustomOfferRequestProvider>();
    loadServices();
  }

  void loadServices() async {
    var data = await _carServiceProvider?.get();
    setState(() {
      carServices = data!;
    });
  }

  @override
  Widget build(BuildContext context) {
    _userProvider = Provider.of<UserProvider>(context, listen: false);
    return MasterScreenWidget(
      index: 1,
      child: Scaffold(
        body: SafeArea(
          child: SingleChildScrollView(
            child: Column(
              children: [
                Container(
                  height: 200,
                  width: MediaQuery.of(context).size.width,
                  margin: const EdgeInsets.only(top: 10),
                  decoration: const BoxDecoration(
                      image: DecorationImage(
                    image: AssetImage('assets/images/background.png'),
                    fit: BoxFit.fill,
                  )),
                  child: Center(
                    child: Container(
                        margin: EdgeInsets.only(top: 160),
                        child: const Text(
                          "Custom offer",
                          style: TextStyle(
                              color: Colors.cyan,
                              fontSize: 40,
                              fontWeight: FontWeight.bold),
                        )),
                  ),
                ),
                Padding(
                  padding: const EdgeInsets.all(50),
                  child: Form(
                    key: _formKey,
                    autovalidateMode: AutovalidateMode.onUserInteraction,
                    child: Column(
                      children: [
                        Column(
                          mainAxisSize: MainAxisSize.min,
                          children: <Widget>[
                            Row(
                              children: [
                                // Text("${selectedDate.toLocal()}".split(' ')[0]),
                                // const SizedBox(
                                //   height: 20.0,
                                // ),
                                ElevatedButton(
                                  onPressed: () => _selectDate(context),
                                  child: Text(selectedDate != null
                                      ? "${selectedDate}"
                                      : 'Select date'),
                                ),
                                SizedBox(width: 20),
                                Container(
                                  child: DropdownButton(
                                      items: _buildCarService(),
                                      value: selectedCarService,
                                      hint: Text("Car service"),
                                      onChanged: (dynamic value) {
                                        setState(() {
                                          selectedCarService = value;
                                        });
                                      }),
                                ),
                              ],
                            ),
                          ],
                        ),
                        Container(
                          margin: const EdgeInsets.only(top: 19),
                          padding: const EdgeInsets.all(10),
                          child: TextFormField(
                            validator: (value) {
                              if (value!.isEmpty) {
                                return "Required field!";
                              }
                            },
                            decoration: const InputDecoration(
                                labelText: "Name your request",
                                labelStyle: TextStyle(
                                  color: Colors.cyan,
                                ),
                                enabledBorder: OutlineInputBorder(
                                    borderSide: BorderSide(
                                        width: 1, color: Colors.cyan))),
                            controller: _nameController,
                          ),
                        ),
                        Container(
                          width: 300,
                          height: 200,
                          child: Card(
                            margin: const EdgeInsets.only(top: 40),
                            color: Color.fromARGB(255, 54, 52, 52),
                            child: Container(
                              decoration: const BoxDecoration(
                                  border: Border(
                                      top: BorderSide(color: Colors.cyan),
                                      bottom: BorderSide(color: Colors.cyan),
                                      right: BorderSide(color: Colors.cyan),
                                      left: BorderSide(color: Colors.cyan))),
                              padding: const EdgeInsets.all(8.0),
                              child: TextFormField(
                                validator: (value) {
                                  if (value!.isEmpty) {
                                    return "Required field!";
                                  }
                                },
                                controller: _descriptionController,
                                maxLines: 5, //or null,
                                decoration: const InputDecoration.collapsed(
                                    hintText: "Enter your description here",
                                    hintStyle: TextStyle(color: Colors.cyan)),
                              ),
                            ),
                          ),
                        ),
                        SizedBox(height: 20),
                        Container(
                          height: 50,
                          margin: EdgeInsets.fromLTRB(50, 20, 50, 0),
                          decoration: BoxDecoration(
                              borderRadius: BorderRadius.circular(10),
                              gradient: const LinearGradient(
                                  colors: [Colors.cyan, Colors.blue])),
                          child: InkWell(
                            onTap: () async {
                              try {
                                if (selectedDate == null ||
                                    selectedCarService == null ||
                                    selectedCarService! < 0) {
                                  throw Exception(
                                      "Date and carService are required fields!");
                                }
                                if (_formKey.currentState!.validate()) {
                                  await _customOfferReqProvider?.insert({
                                    'name': _nameController.text,
                                    'description': _descriptionController.text,
                                    'date': selectedDate,
                                    'carServiceId': selectedCarService,
                                    'userId': UserLogin.user!.userId,
                                    'status': "Active",
                                  });
                                  showDialog(
                                      context: context,
                                      builder: (BuildContext context) =>
                                          AlertDialog(
                                            title: const Text("Success"),
                                            content: const Text(
                                                "Rating successfully added!"),
                                            actions: [
                                              TextButton(
                                                  onPressed: () async =>
                                                      await Navigator.pushNamed(
                                                          context,
                                                          OfferListScreen
                                                              .routeName),
                                                  child: const Text("Ok"))
                                            ],
                                          ));
                                }
                              } on Exception catch (e) {
                                showDialog(
                                    context: context,
                                    builder: (BuildContext context) =>
                                        AlertDialog(
                                          title: const Text("Error ocurred"),
                                          content: Text(e.toString()),
                                          actions: [
                                            TextButton(
                                              child: const Text("Ok"),
                                              onPressed: () =>
                                                  Navigator.pop(context),
                                            )
                                          ],
                                        ));
                              }
                            },
                            child: const Center(child: Text("Send request")),
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  List<DropdownMenuItem> _buildCarService() {
    if (carServices.isEmpty) {
      return [];
    }
    List<DropdownMenuItem> list = <DropdownMenuItem>[];

    list.add(const DropdownMenuItem(
      enabled: false,
      value: -1,
      child: Text("Select the service", style: TextStyle(color: Colors.black)),
    ));

    list.addAll(carServices
        .map((x) => DropdownMenuItem(
              value: x.carServiceId,
              child: Text(x.name!, style: const TextStyle(color: Colors.white)),
            ))
        .toList());

    return list;
  }

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
        context: context,
        initialDate: DateTime.now(),
        firstDate: DateTime(2015, 8),
        lastDate: DateTime(2101));

    if (picked != null && picked != selectedDate) {
      setState(() {
        String formated = DateFormat('yyyy-MM-dd').format(picked);
        selectedDate = formated;
      });
    }
  }
}
