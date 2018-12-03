$(document).ready(function() {
  $(".generate").click(function(){  
    $.ajax({
      type: "GET",
      url: "/Generate",
      dataType: "json"
    }).done(function(response){
      $(".password").html(response.randomPassword);
      $(".numcodes").html(`Random Passcode (passcode ${response.numGeneratedPasswords})`);
    })
  })
})