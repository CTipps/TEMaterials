document.addEventListener("DOMContentLoaded", () {

    const time = document.querySelector('.btn');
  time.addEventListener('click', displayTime());
   
  function displayTime() { 
       return document.getElementById('time').innerText = Date.now();
    }
  });

