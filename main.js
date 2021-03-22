import {Polica} from "./polica.js";
import { Biblioteka } from "./biblioteka.js";
import { Knjiga } from "./knjiga.js";


fetch("https://localhost:5001/Biblioteka/PreuzmiBiblioteke").then(b=>{
 b.json().then(e=>{

e.forEach(el => {
const cb = new Biblioteka(el.id,el.ime);
cb.crtajBiblioteku(document.body);

   el.police.forEach(p =>{
        const cp = new Polica(p.id,p.zanr,p.brKnjiga);
        cb.dodajPolicu(cp);
        cb.prikaziPolicu(cp);

        fetch("https://localhost:5001/Biblioteka/PreuzmiKnjige/"+p.id).then(k1=> k1.json().then(k2=> k2.forEach(k3=> {
              const k = new Knjiga(k3.id,k3.ime,k3.brStrana);
              cp.dodajKnjigu(k);
              cp.osveziStatus();
             // cp.obojiKnjige(k3.ime,k3.brStrana);
              
        })));

       
    });



});
  
});
});



/*let b=new Biblioteka("Stevan Sremac");

let p=new Polica("Akcioni", 10);
b.dodajPolicu(p);

p=new Polica("Biografski", 5);
b.dodajPolicu(p);


p=new Polica("Romantika", 5);
b.dodajPolicu(p);

p=new Polica("Fantastika", 6);
b.dodajPolicu(p);

p=new Polica("Krimi", 3);
b.dodajPolicu(p);

b.crtajBiblioteku(document.body);


 b=new Biblioteka("Stevan Sremac1");

 p=new Polica("Akcioni", 10);
b.dodajPolicu(p);

p=new Polica("Biografski", 5);
b.dodajPolicu(p);


p=new Polica("Romantika", 5);
b.dodajPolicu(p);

p=new Polica("Fantastika", 6);
b.dodajPolicu(p);

p=new Polica("Krimi", 3);
b.dodajPolicu(p);

b.crtajBiblioteku(document.body);*/