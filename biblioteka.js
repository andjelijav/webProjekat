import { Knjiga } from "./knjiga.js"

export class Biblioteka
{
    constructor(id,naziv)
    {
        this.id = id;
        this.naziv=naziv;
        this.listaPolica=[];

        this.container=null;

    }
    
    dodajPolicu(polica)
    {
        this.listaPolica.push(polica);
    }

    prikaziPolicu(polica)
    {
        polica.crtajPolicu(this.container.querySelector(".levo"));

        let radioLab=document.createElement("div");
        radioLab.className="radioLab";
        this.container.querySelector(".goreradio").appendChild(radioLab);

        let radio=document.createElement("input");
        radio.type="radio";
        radio.name="r";
        radio.value=this.listaPolica.length-1;
        radioLab.appendChild(radio);

        const labela=document.createElement("label");
        labela.innerHTML=polica.zanr;
        radioLab.appendChild(labela);

    }


   crtajBiblioteku(roditelj)
   {
    
    this.container=document.createElement("div");
    this.container.className="biblioteka";
    roditelj.appendChild(this.container);

    let labela=document.createElement("h1");
    labela.innerHTML="Biblioteka: "+ this.naziv;
    labela.className="l1";
    this.container.appendChild(labela);

    labela=document.createElement("label");
    labela.innerHTML="Izmeni ime biblioteke";
    this.container.appendChild(labela);

    let imeBiblioteke=document.createElement("input");
    imeBiblioteke.className="imeBiblioteke";
    this.container.appendChild(imeBiblioteke);

    let dugme2=document.createElement("button");
    dugme2.innerHTML="IZMENI IME";
    dugme2.className="imeBiblioteke1";
    dugme2.onclick=(ev)=>this.klik3();
    this.container.appendChild(dugme2);

    let dole1=document.createElement("div");
    dole1.className="dole1";
    this.container.appendChild(dole1);

    let dole=document.createElement("div");
    dole.className="dole";
    this.container.appendChild(dole);

    let levo=document.createElement("div");
    levo.className="levo";
    dole.appendChild(levo);

    let ispod=document.createElement("div");
    ispod.className="ispod";
    this.container.appendChild(ispod);

    const goreradio = document.createElement("div");
    goreradio.className = "goreradio";
    ispod.appendChild(goreradio)
    
    this.listaPolica.forEach((el, ind)=>
    {
        el.crtajPolicu(levo);

        let radioLab=document.createElement("div");
        radioLab.className="radioLab";
        goreradio.appendChild(radioLab);

        let radio=document.createElement("input");
        radio.type="radio";
        radio.name="r";
        radio.value=ind;
        radioLab.appendChild(radio);

        labela=document.createElement("label");
        labela.innerHTML=el.zanr;
        radioLab.appendChild(labela);

    })

    let kolicinaDiv=document.createElement("div");
    kolicinaDiv.className="kolicinaDiv";
    ispod.appendChild(kolicinaDiv);

    let nazivh1 = document.createElement("h3");
    kolicinaDiv.className="nazivh1";
    nazivh1.innerHTML="Dodaj knjigu"
    kolicinaDiv.appendChild(nazivh1);

    labela=document.createElement("label");
    labela.innerHTML="Ime knjige";
    kolicinaDiv.appendChild(labela);

    let unosImena=document.createElement("input");
    unosImena.className="unosImena";
    kolicinaDiv.appendChild(unosImena);

    labela=document.createElement("label");
    labela.innerHTML="Broj stranica";
    kolicinaDiv.appendChild(labela);

    let brojStranica=document.createElement("input");
    brojStranica.className="brojStranica";
    kolicinaDiv.appendChild(brojStranica);

    let dugme=document.createElement("button");
    dugme.innerHTML="UCITAJ";
    dugme.onclick=(ev)=>this.klik();
    kolicinaDiv.appendChild(dugme);

    let nazivh2 = document.createElement("h3");
    kolicinaDiv.className="nazivh1";
    nazivh2.innerHTML="Obrisi knjigu"
    kolicinaDiv.appendChild(nazivh2);

    let dugme1=document.createElement("button");
    dugme1.innerHTML="OBRISI POSLEDNJU KNJIGU";
    dugme1.onclick=(ev)=>this.klik2();
    kolicinaDiv.appendChild(dugme1);

    


   }

   klik()
   {
    let pom=this.container.querySelector("input[type=radio]:checked").value;
    let ime = this.container.querySelector(".unosImena").value;
    let stranice = this.container.querySelector(".brojStranica").value;
    if(this.listaPolica[pom].ukupnoK == this.listaPolica[pom].trenutno)
    {
        alert('Prekoracenje!');
    }
    else
    {
      //   this.listaPolica[pom].trenutno+=parseInt(1);
         this.listaPolica[pom].osveziStatus();
         this.listaPolica[pom].dodajKnjigu(new Knjiga(-1,ime,stranice))//obojiKnjige(ime,stranice);
    }
   }

   klik2()
   {
        const el =  this.container.querySelector("input[type=radio]:checked");
        
        if(el == null)
        {
            alert("Odaberite policu iz koje brisete!");
            return;
        }
        let pom=el.value;
       	if(this.listaPolica[pom].trenutno==0)
		{
			alert('Nema knjiga za brisanje.')
        }
        else
        {

            this.listaPolica[pom].trenutno-=parseInt(1);
            this.listaPolica[pom].osveziStatus();
            this.listaPolica[pom].brisiKnjige();
        }
   }

   klik3()
   {
        let ime = this.container.querySelector(".imeBiblioteke").value;
        if(ime == "")
        {
            alert("Ime biblioteke ne moze biti prazno.");
        }
        else
        {
            this.container.querySelector(".l1").innerHTML='Biblioteka: ' + ime;

            fetch("https://localhost:5001/Biblioteka/PromeniIme/"+this.id+"/"+ime,{method:"PUT"});

        }

   }
}





