import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";

import Header from '@/components/header';
import Providers from "./providers";
import "./globals.css"
import Sidebar from "@/components/sidebar";



const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
  title: "Recipe Rolodex",
  description: "Look at all the food I won't make!",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <div className="container mx-auto px-4 max-w-6nl ">
        
          <Providers>
            <Header />
              <div className="grid grid-cols-4 gap-4 p-4 h-full" >
                <div className="col col-span-1 bg-green-400 p-4 ">
                 <Sidebar/>
                </div>
                <div className="col col-span-3">
                  
                {children} 
                </div>          
            </ div>
          </Providers>
          </div> 
          
      </body>
    </html>
  );
}
