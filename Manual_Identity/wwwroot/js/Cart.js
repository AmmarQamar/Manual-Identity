$(document).ready(function () {
  

    var totalprice=0;
    var totalamount=0;
    var count=0;
    var content;
    var cal;
    $(".addtocart").click(function()
    {
          var invoice =$("#invoice_id").val();
    var customer =$("#customer_id").val();
    var item =$("#item_id").val();
    var itemName =$("#item_id").text();
    var quantity =$("#quantity_id").val();
    var unitprice = $("#unitprice_id").val();
    var carttitle=$(".customer-title");
    var itemtitle=$(".item-title");
    //totalamount=totalprice+totalamount;
    var totalprice=(quantity*unitprice);
    // Already Exists
    for(var i=0;i<carttitle.length; i++)
    { 
       if(carttitle[i].innerText==customer && itemtitle[i].innerText==item )
       {
         alert("Already Exist Item so quantity update ");
         debugger;
         var c_quant=$(".quantity");
         var c_price=$(".price");
         var c_total=$(".total");
         //var o_total=c_total[i].innerText;
         var o_total=$(".total")[i].innerText;
         c_price[i].innerHTML=unitprice;
         c_quant[i].innerHTML=quantity;
         c_total[i].innerHTML=totalprice;
         totalamount=totalamount+totalprice-o_total;
         $('#totalamount_id').val(totalamount);
         return
        }
     }
    if(count==0)
    {
        content ="<div class='row'> <div class='col-sm-2'>Customer Id</div> <div class='col-sm-2'>Item Id</div> <div class='col-sm-2'>Item Name</div> <div class='col-sm-2'>Quantity</div> <div class='col-sm-2'>Unit Price</div>  <div class='col-sm-2'>Total Price</div></div>"
        //content ="<label class='form-label'>Customer Id<label> <label class='form-label'>Item Id<label> <label class='form-label'>Item Name<label> <label class='form-label'>Quantity<label> <label class='form-label'>Unit Price<label>"
        //content = "<tr><th>InVoice No</th><th>Customer Id</th><th>Item Id</th><th>Item Name</th><th>Quantity</th><th>Unit Price</th><th>Total Price</th></tr>";
    $('#show_tab').append(content);
    count++;
        }
        content = "<div class='row jscartitem'> <div class='jrcart col-sm-2 customer-title'/>" + customer + "</div> <div class='jrcart col-sm-2 item-title'>" + item + "</div>  <div class='col-sm-2 jrcart'>" + itemName + "</div> <div class=' jrcart col-sm-2 quantity'>" + quantity + "</div> <div class='jrcart col-sm-2 price'>" + unitprice + "</div> <div class='col-sm-2 total'>" + totalprice + "</div</div>"
    //content="<tr><td>"+invoice+"</td> <td class='customer-title'>"+customer+"</td> <td class='item-title'>"+item+"</td> <td>"+itemName+"</td>  <td class='quantity'>"+quantity+"</td> <td class='price'>"+unitprice+"</td> <td class='total'>"+totalprice+"</td</tr>"
        $('#show_tab').append(content);
        count++;
        totalamount=totalprice+totalamount;
        //total amount,paid amount,total balance
        $('#to').css('display', 'flex');

        var t_a= $('#totalamount_id').val(totalamount);
        $('#paidamount_id').keyup(function(){
           var value1 = parseFloat($('#totalamount_id').val()) || 0;
        var value2 = parseFloat($('#paidamount_id').val()) || 0;
        $('#balanceamount_id').val(value2 - value1);
            });

      });
        //function  calculatebalance(){
        //    debugger;
        //       var t_a= $('#totalamount_id').val();
        //       var p_a= $('#paidamount_id').val();
        //       var res= p_a-t_a;
        //       var c= $('#balanceamount_id').val(res);
        //}

});