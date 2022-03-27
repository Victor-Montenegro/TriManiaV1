# TriManiaV1
Projeto com a finalidade de praticar os conceitos de arquitetura limpa, CQRS, MediatR e EF.

# Passos a Passos
  Realize o clone do repositorio na sua maquina 
  
  Ao abrir o projeto no Visual Studio:
    Vá em SolutionExplorer 
    
  ![image](https://user-images.githubusercontent.com/56697589/160260118-216c2a65-3346-4549-a4e3-dadf2b8a69db.png)


Abra a pasta TriMania_V1 e clique duas vezes em TriMania_V1.sln
   ![image](https://user-images.githubusercontent.com/56697589/160260125-86bbb667-71d1-468f-8203-ba42d260f7a9.png)


No projeto TriMania_V1, clique com o botão direito e vá em properties
![image](https://user-images.githubusercontent.com/56697589/160260235-17773e86-57ac-4293-a37a-43be7cd10271.png)

   
Na categoria build -> Output path --> --> XML document file -> Desmarque e marque novamente para que o visual Studio pegue o caminho correto do seu repositorio para gerar o xml do swagger.
![image](https://user-images.githubusercontent.com/56697589/160260292-2b3664c9-c2bd-4292-aa1e-c1e5c3b2e52b.png)

Salve a alteração e realize o Rebuild Solution

![image](https://user-images.githubusercontent.com/56697589/160260354-20a1f449-85e0-4fbb-b8f2-18ad43a836a8.png)

Antes de executar os passos a a seguir para realizar a criação do banco de dados. Certifique-se se o serviço MySql está rodando, caso não esteja, coloque em execução

![image](https://user-images.githubusercontent.com/56697589/160260691-88024ddc-a9ee-4713-b148-c702e653144a.png)

Caso você não tenha o MySql instalado realize a instação atraves desse site: https://dev.mysql.com/downloads/mysql/

No arquivo ContextFactory.cs | appsettings.json | BaseRepositoryDP.cs: altere a connectionString para o user e a senha do seu localhost configurado na instalação
![image](https://user-images.githubusercontent.com/56697589/160260823-b1e2ebf0-04d2-42ce-a724-963477117c92.png)
![image](https://user-images.githubusercontent.com/56697589/160261039-84dc8fbe-c2b8-4cf9-b0c8-d9cac763baf6.png)
![image](https://user-images.githubusercontent.com/56697589/160261051-4947f02f-4ab5-43f8-9dc6-28337375fdff.png)

No projeto Infrastructure clique com o botão direito e clique em : Set as Startup Project

![image](https://user-images.githubusercontent.com/56697589/160260534-19434bd7-014d-4a1e-91d6-991ea6d00483.png)

Em Tools --> NuGet Package Manager --> Package Manager Console

![image](https://user-images.githubusercontent.com/56697589/160260589-943c21af-c8c0-4098-baee-8d4fe5676595.png)


Selecione Infrastructure

![image](https://user-images.githubusercontent.com/56697589/160260606-4eb347fc-549a-4e00-adfb-4a2e09218715.png)


Coloque o comando a seguir e aperte enter:

    Update-Database

Resultado esperado: 
![image](https://user-images.githubusercontent.com/56697589/160260896-f127b857-5d6e-4a95-a260-3b320aeb8efc.png)

No projeto TriMania_V1 clique com o botão direito e selecione: Set as Startup Project
![image](https://user-images.githubusercontent.com/56697589/160260946-4fe84811-21a9-4e49-b8ae-29b74caab3ef.png)

Realize a alteração para TriMania_V1
![image](https://user-images.githubusercontent.com/56697589/160260984-e53f6f0f-25d0-4259-8c3f-794316f8f55d.png)

Aperte F5

Resultado esperado:
![image](https://user-images.githubusercontent.com/56697589/160261070-05d896c4-3532-482b-a078-13b549506819.png)

para realizar o login com o admin:

    {
      "login": "admin",
      "passworld": "123456"
    }



