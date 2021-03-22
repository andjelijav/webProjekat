//import { Knjiga } from './knjiga.js' 

export class Polica
{
    constructor(id,zanr,ukupnoK)
    {
		this.id = id;
        this.zanr=zanr;
        this.ukupnoK=ukupnoK;

        this.listaKniga = [];

        this.trenutno=0;

        this.container=null;
    }

    dodajKnjigu(knjiga)
	{
       //if -1 kreirana 
	   if(knjiga == null)
	   return;

		if(knjiga.id == -1)
		{
			fetch("https://localhost:5001/Biblioteka/UbaciKnjigu/"+this.id,{
				headers:{ 
					"Content-Type":"application/json"
					},
			method:"POST",
			body:JSON.stringify(
				{
					"ime": knjiga.naziv,
					"brStrana": knjiga.ukupnoS
				}
			)
			}).then(el=> knjiga.id = el.status);
			
		}
	

		this.listaKniga.push(knjiga);
		const cc = this.container.querySelectorAll(".knjiga")[this.trenutno];
		cc.style.backgroundColor = "lightblue";
		knjiga.crtajKnjigu(cc);
		this.trenutno++;
	}

    crtajPolicu(roditelj)
    {
        this.container=document.createElement("div");
        this.container.className="polica";
		roditelj.appendChild(this.container);
		
        let labela=document.createElement("label");
        labela.className="zanr";
		labela.innerHTML=this.zanr+ " ";
        this.container.appendChild(labela);
        
    
		
		let knjige=document.createElement("div");
		knjige.className="knjige";
		this.container.appendChild(knjige);
		
		for(let i=0; i<this.ukupnoK;i++)
		{
			let knjiga=document.createElement("div");
			knjiga.className="knjiga";
			
			knjige.appendChild(knjiga);
			
		}
		
		labela=document.createElement("label");
		labela.innerHTML=this.trenutno+"/"+this.ukupnoK;
		labela.className="statusLab";
		this.container.appendChild(labela);
		
	//	this.obojiKnjige();
		
	}
	
	osveziStatus()
	{
		this.container.querySelector(".statusLab").innerHTML=this.trenutno+"/"+this.ukupnoK;
	}
	
	/*obojiKnjige(ime, stranice)
	{
		this.container.querySelectorAll(".knjiga").forEach((el, i)=>
		{
			if(i==this.trenutno-1)
			{
				el.style.backgroundColor="lightblue";
				var k = new Knjiga(id,ime, stranice);
				this.dodajKnjigu(k);
				k.crtajKnjigu(el);
			}
        });

    }*/


    brisiKnjige()
	{
			const k = this.container.querySelectorAll(".knjiga")[this.trenutno];
			k.style.backgroundColor="white";
			k.innerHTML = "";
			
			const c = this.listaKniga.pop();
			fetch("https://localhost:5001/Biblioteka/IzbrisiKnjigu/"+c.id,{method:"DELETE"});
        }

}