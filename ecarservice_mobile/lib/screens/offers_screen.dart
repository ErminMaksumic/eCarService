import 'dart:ui';

import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutterv1/model/part.dart';
import 'package:flutterv1/providers/offer_provider.dart';
import 'package:flutterv1/utils/util.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../model/offer.dart';

class OfferListScreen extends StatefulWidget {
  static const String routeName = "/offersList";
  const OfferListScreen({Key? key}) : super(key: key);

  @override
  State<OfferListScreen> createState() => _OfferListScreenState();
}

class _OfferListScreenState extends State<OfferListScreen> {

  OfferProvider? _offerProvider = null;
  List<Offer> data = [];
  List<String>? partsNames;

  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _offerProvider = context.read<OfferProvider>();
    print("called initState");
    loadData();
  }

  Future loadData() async {
    var tmpData = await _offerProvider?.get(null);
    setState(() {
      data = tmpData!;
    });

  }

  @override
  Widget build(BuildContext context) {
      return Scaffold(
        body: SafeArea(child: SingleChildScrollView(
        child:  Column(
              //crossAxisAlignment: CrossAxisAlignment.start,
              children: buildAll()
            ),
          ),
        ),
      );
  }


     List<Widget> buildAll()
    {
    List<Widget> list = <Widget>[];

    list.add(_buildHeader());
    list.add(_buildOfferSearch());
    list.addAll(_buildCard());
 
     return list;
    
   }

  
List<Widget> _buildProductCardList(){
  if(data.length == 0){
    return [const Text("Loading...")];
  }

  List<Widget> list = data.map((x) => 
  Container(
    height: 200,
    width: 200,
    child: Column(
      children: [
        Container(
          height: 50,
          width: 100,
          child: imageFromBase64String(x.image!),
        ),
        Text(x.name ?? ""),
        Text(formatNumber(x.price)),
      ],
    ),
  )).cast<Widget>().toList();

  return list;
}

Widget _buildHeader()
{
  return Container(
    padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
    child: Text("Offers", style: TextStyle(color: Colors.cyan, fontWeight:FontWeight.bold ,fontSize: 40),),
  );
  
}

Widget _buildOfferSearch(){
    return Row(
      children: [
        Expanded(
        child: Container(
          padding: const EdgeInsets.symmetric(
            horizontal: 20,
            vertical: 10
          ), 
          child: TextField(
            controller: _searchController,
            onSubmitted:(value) async {
              var tempData = await _offerProvider?.get({'name': value});
              setState(() {
                data = tempData!;
              });
            },
            decoration: InputDecoration(
              hintText: "Search offers",
              prefixIcon: const Icon(Icons.search),
              border: OutlineInputBorder(
                borderRadius: BorderRadius.circular(10),
                borderSide: const BorderSide(color: Colors.grey),
              )
            ),
          )
          ),
        ),
        Container(
          padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
          child: IconButton(
            icon: Icon(Icons.filter_list),
            color: Colors.cyan,
            onPressed: () async{
               var tempData = await _offerProvider?.get({'name': _searchController.text});
              setState(() {
                data = tempData!;
              });
            },
          ),
        )
      ],
    );
}

List<Widget> _buildCard(){
  if(data.length == 0){
    return [const Text("Loading...")];
  }

  List<Widget> list = data.map((x) => 
      
      Padding(
        padding: const EdgeInsets.all(10.0),
        child: Container(
          color: Colors.cyan,
          child: Container(
            child: 
              Stack(
                children: [
                  Column(
                    children: [
                      Container(
                        height: 130,
                        width: 500,
                        child: Image.memory(
                          dataFromBase64String(x.image!),
                          fit: BoxFit.cover
                        ),
                      ),
                       Container(
                        height: 130,
                      child:
                        Column(
                          children: [
                            Row(
                             mainAxisAlignment: MainAxisAlignment.center,
                             crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Text(x.name!, textAlign: TextAlign.center, style: TextStyle(color: Colors.black, fontWeight: FontWeight.bold, fontSize: 25),),
                            ],
                      ),
                        SizedBox(height: 10),
                            Row(
                             mainAxisAlignment: MainAxisAlignment.start,
                             crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                               const LimitedBox(
                                child: Text("- Included parts: ",  overflow: TextOverflow.ellipsis, textAlign: TextAlign.center, style: TextStyle(color: Colors.black, fontWeight: FontWeight.bold, fontSize: 15)),
                             ),
                               Text(x.parts!.length > 3 ? "${x.partNames!}, ..." : x.parts!.length < 3 ? x.partNames! : "Not specified",  
                               textAlign: TextAlign.center,
                                style: const TextStyle(color: Colors.red, 
                                fontWeight: FontWeight.bold, fontSize: 15),
                              ),
                            ],
                      ),
                      const SizedBox(height: 5,),
                            Row(
                             mainAxisAlignment: MainAxisAlignment.start,
                             crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                                const LimitedBox(
                                  child: Text("- For brands: ", 
                                   overflow: TextOverflow.ellipsis, 
                                   textAlign: TextAlign.center, 
                                   style: TextStyle(color: Colors.black, 
                                   fontWeight: FontWeight.bold, 
                                   fontSize: 15)),
                            ),
                               Text(x.carBrands!.length > 3 ? "${x.carBrandNames}, ..." : x.carBrands!.length < 3 ? x.carBrandNames! : "Not specified",  
                                textAlign: TextAlign.center,
                                style: const TextStyle(color: Colors.red, 
                                fontWeight: FontWeight.bold, fontSize: 15),
                              ),
                            ],
                      ),
                        const SizedBox(height: 5,),
                      Row(
                             mainAxisAlignment: MainAxisAlignment.start,
                             crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              const Text("- Price: ", 
                              textAlign: TextAlign.center, 
                              style: TextStyle(
                                color: Colors.black, 
                                fontWeight: FontWeight.bold, 
                                fontSize: 15),),
                                Text(formatNumber(x.price) + " \$",  
                                textAlign: TextAlign.center,
                                style: const TextStyle(color: Colors.deepOrange, 
                                fontWeight: FontWeight.bold,
                                fontSize: 15))
                            ],
                      ),
                        Row(
                            mainAxisAlignment: MainAxisAlignment.end,
                            // ignore: prefer_const_literals_to_create_immutables
                            children: [
                              const Text("More info", textAlign: TextAlign.center, style: TextStyle(color: Colors.black, fontWeight: FontWeight.bold, fontSize: 15),),
                            ],
                      ),
                          ],
                        ),
                ),
                      
                    ],
                  )
                ],
              )
          ),
        ),
      ),
      ).cast<Widget>().toList();
      return list;
}
}
