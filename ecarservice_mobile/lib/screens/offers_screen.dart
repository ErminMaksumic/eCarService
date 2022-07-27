import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutterv1/providers/offer_provider.dart';
import 'package:flutterv1/utils/util.dart';
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
        body: SafeArea(
          child: SingleChildScrollView(
          child: Container(
            child: Column(
              //crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                _buildHeader(),
                Container(
                  height: 200,
                child: GridView(
                  gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                    crossAxisCount: 1,
                    childAspectRatio: 4 / 3,
                    crossAxisSpacing: 20,
                    mainAxisSpacing: 30
                  ),
                  scrollDirection: Axis.horizontal,
                  children: _buildProductCardList(),
                ),
                )
              ],
            ),
          ),
        ),
        )
      );
  }

  
List<Widget> _buildProductCardList(){
  if(data.length == 0){
    return [Text("Loading...")];
  }

  List<Widget> list = data.map((x) => 
  Container(
    height: 200,
    width: 200,
    child: Column(
      children: [
        Container(
          height: 100,
          width: 100,
          child: imageFromBase64String(x.image!),
        ),
        Text(x.name ?? ""),
      ],
    ),
  )).cast<Widget>().toList();

  return list;
}
}

Widget _buildHeader()
{
  return Container(
    padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
    child: Text("Offers", style: TextStyle(color: Colors.cyan, fontWeight:FontWeight.bold ,fontSize: 40),),
  );
}