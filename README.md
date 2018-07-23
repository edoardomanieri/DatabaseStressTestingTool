# StressTestC--tirocinio

Programma di StressTest per la tabella WipHeaderHistory del database WIP.
Lancia in parallelo un numero a scelta di processi che interrogano MongoDB e SQLServer simulando delle stazioni.

Il server di MongoDB deve girare in locale sulla porta 27017(default).
la connection string per SQLServer è editabile e va messa seguendo il modello di quella presente a default.

Database di SQLServer -> WIP_Test [ per editarlo modificare il metodo main della classe Program che si trova in res\SQLServerThread\SQLServerThread e il metodo button1_Click della classe Form1 ]
Database di MongoDB -> WIP [ per editarlo modificare il metodo main della classe Program che si trova in res\MongoThread\MongoThread ]

Per cambiare le query eseguite su SQLServer modificare il metodo main della classe Program che si trova in res\SQLServerThread\SQLServerThread.
Per cambiare le query eseguite su MongoDB modificare il metodo main della classe Program che si trova in res\MongoThread\MongoThread. 

le tabelle devono essere ovviamente popolate.

Premendo il tasto getResults si ottiene un file di testo con i tempi di risposta.
