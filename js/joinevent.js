$("#btn1").click(function(e){
   console.log("1Works");
   e.preventDefault();
   console.log("Works");
   $.ajax({type: "GET",
  //       data: vote,
        //  dataType: "text",
         url: "http://accompany.nanek.name/api/vote.php?id=4",
         success: function(vote){
           console.log("Success!");
           $("#vote1").html(vote);
         },
         error: function(xmlHttpRequest, textStatus, errorThrown) {
           console.log("Error: " + errorThrown);
         }
    });
});

$("#btn2").click(function(e){
     e.preventDefault();
     $.ajax({type: "POST",
           url: "http://accompany.nanek.name/api/vote.php?id=4",
           success: function(data) {

           }
   });
 });


$("#btn3").click(function(e){
     e.preventDefault();
     $.ajax({type: "POST",
           url: "http://accompany.nanek.name/api/vote.php?id=4"
   });
 });
