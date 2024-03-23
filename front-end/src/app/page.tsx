import Header from "@/components/header";
import RecipesList from "@/components/recipes-list";

export default function Home() {




  return (
    <div className="grid grid-cols-4 gap-4 p-4">

      <div className="col-span-3">
        <RecipesList />
      </div>
    </div>

  );
}
