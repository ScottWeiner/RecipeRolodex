import Header from "@/components/header";
import RecipesList from "@/components/recipes-list";
import Sidebar from "@/components/sidebar";

export default function Home() {




  return (

    
      
      <div className="col-span-3 p-4">
        <div className="text-lg bg-orange-200 grid justify-items-center mb-4">
          <h1>Favorite Recipes</h1>
        </div>
        <RecipesList />
      </div>
  

  );
}
