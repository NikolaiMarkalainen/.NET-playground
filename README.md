ip -4 addr show docker0 
This command allowed me to find the correct ipv4 string
to connect to my database properly.
Now this address is used in .NET to connect to PGSQL database

Other solutions didnt seem feasible as 0.0.0.0 or 127.0.0.1
or localhost or postgres didnt work for host links.