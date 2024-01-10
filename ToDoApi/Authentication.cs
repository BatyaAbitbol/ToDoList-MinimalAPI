
// // // Authentication

// // object CreateJWT(User user)
// // {
// //     var claims = new List<Claim>()
// //     {
// //         new Claim("id", user.Id.ToString()),
// //         new Claim("name", user.Name ?? "")
// //     };
// //     var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder?.Configuration.GetValue<string>("JWT:key") ?? ""));
// //     var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
// //     var tokenOptions = new JwtSecurityToken(
// //         issuer: builder?.Configuration.GetValue<string>("JWT:Issuer"),
// //         audience: builder?.Configuration.GetValue<string>("JWT:Audience"),
// //         claims: claims,
// //         expires: DateTime.Now.AddHours(1),
// //         signingCredentials: signingCredentials
// //     );
// //     var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
// //     return new { Token = tokenString };
// // }

// // app.MapPost("/login", (ToDoDBContext context, LoginModel loginModel) =>
// // {
// //     var user = context.Users.FirstOrDefault(u => u.Name == loginModel.Name && u.Password == loginModel.Password);
// //     if (user is not null)
// //     {
// //         var jwt = CreateJWT(user);
// //         return Results.Ok(jwt);
// //     }
// //     return Results.Unauthorized();
// // });

// // // app.MapPost("/register", ())



// // app.UseAuthentication();
// // app.UseAuthorization();


// // .AddJwtBearer(options =>
// // {
// //     options.TokenValidationParameters = new TokenValidationParameters
// //     {
// //         ValidateIssuer = true,
// //         ValidateAudience = true,
// //         ValidateLifetime = true,
// //         ValidateIssuerSigningKey = true,
// //         ValidIssuer = builder.Configuration["JWT:Issuer"],
// //         ValidAudience = builder.Configuration["JWT:Audience"],
// //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"] ?? ""))
// //     };
// // });

// /*
// options =>
// {
//     options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//     {
//         Scheme = "Bearer",
//         BearerFormat = "JWT",
//         In = ParameterLocation.Header,
//         Name = "Authorization",
//         Description = "Bearer Authentication with JWT Token",
//         Type = SecuritySchemeType.Http
//     });
//     options.AddSecurityRequirement(new OpenApiSecurityRequirement
//     {
//         {
//             new OpenApiSecurityScheme
//             {
//         Reference = new OpenApiReference
//                 {
//                     Id = "Bearer",
//                     Type = ReferenceType.SecurityScheme
//                 }
//             },
//             new List<string>()
//         }
//     });
// }
// */
// // builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, CustomAuthorizationHandler>();

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// });