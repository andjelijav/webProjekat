export class Knjiga
{
    constructor(id,naziv, ukupnoS)
    {
        this.id = id;
        this.naziv=naziv;
        this.ukupnoS=ukupnoS;
        this.trenutnoP=0;
        this.container=null;
    }

    crtajKnjigu(host)
    {
        this.container=document.createElement("div");
        this.container.className="knjigacont";
        host.appendChild(this.container);
        
        let labela = document.createElement('labela');
        labela.className="knjigatabela"
        this.container.appendChild(labela);
        labela.innerHTML= "Naziv: " + this.naziv + "</br>" + "Br. stranica: " + this.ukupnoS; 
    }

}